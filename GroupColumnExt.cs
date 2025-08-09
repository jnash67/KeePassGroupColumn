/*
  KeePass GroupColumn Plugin
  Copyright (C) 2021 Jonathan Nash

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using KeePass.Forms;
using KeePass.Plugins;
using KeePass.UI;

using KeePassLib;


namespace GroupColumn
{
	public sealed class GroupColumnExt : Plugin
	{
		private static IPluginHost g_host = null;
		private GroupColumnProvider m_prov = null;

		internal static IPluginHost Host
		{
			get { return g_host; }
		}

		public override bool Initialize(IPluginHost host)
		{
			Terminate();

			if(host == null) { Debug.Assert(false); return false; }
			g_host = host;

			m_prov = new GroupColumnProvider();
			g_host.ColumnProviderPool.Add(m_prov);

			g_host.MainWindow.FileClosed += this.OnFileClosed;

			return true;
		}

		public override void Terminate()
		{
			if(g_host == null) return;

			g_host.MainWindow.FileClosed -= this.OnFileClosed;

			g_host.ColumnProviderPool.Remove(m_prov);
			m_prov = null;

			g_host = null;
		}

		private void OnFileClosed(object sender, FileClosedEventArgs e)
		{
			GroupColumnProvider.ClearCache();
		}

		public override string UpdateUrl
		{
			get { return "https://raw.githubusercontent.com/jnash67/KeePassGroupColumn/master/version.txt"; }
		}
	}

	public sealed class GroupColumnProvider : ColumnProvider
	{
		private const string GcpName = "Group";

		private static object g_oCacheSync = new object();
		private static Dictionary<string, uint> g_dCache =
			new Dictionary<string, uint>();

		private readonly string[] m_vColNames = new string[] { GcpName };
		public override string[] ColumnNames
		{
			get { return m_vColNames; }
		}

		public override HorizontalAlignment TextAlign
		{
			get { return HorizontalAlignment.Left; }
		}

		internal static void ClearCache()
		{
			lock(g_oCacheSync)
			{
				g_dCache.Clear();
			}
		}

		public override string GetCellData(string strColumnName, PwEntry pe)
		{
			if(strColumnName == null) { Debug.Assert(false); return string.Empty; }
			if(strColumnName != GcpName) return string.Empty;
			if(pe == null) { Debug.Assert(false); return string.Empty; }

			PwDatabase db = GroupColumnExt.Host.Database;
			PwGroup rg = db.RootGroup;
			PwGroup pg = pe.ParentGroup;

			String path = pg.Name;
            while (pg.ParentGroup != null)
            {
                path = pg.ParentGroup.Name + "/" + path;
                pg = pg.ParentGroup;
            }

            return path + "/" +
				pe.ParentGroup.GetEntriesCount(false) + "/" +
				pe.ParentGroup.GetEntriesCount(true);
		}
    }
}
