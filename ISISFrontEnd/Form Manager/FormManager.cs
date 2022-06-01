using System;
using System.Collections;
using System.Windows.Forms;

namespace ISISFrontEnd
{
    public static class FormManager
    {
        #region Declarations
        private static ArrayList list = new ArrayList();
        #endregion


        
      
        public static event EventHandler<FormRemovedEventArgs> FormRemoved;
        public static event EventHandler<FormAddedEventArgs> FormAdded;
        public static event EventHandler<FormPopupAddedEventArgs> PopupAdded;
        public static event EventHandler<FormPopupRemovedEventArgs> PopupRemoved;


        #region Methods
        /// <summary>
        /// Returns true if the Survey Editor with specified index is open 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool EditorOpen (int index)
        {
            foreach (Form f in list)
            {
                if (f.Name.Equals("SurveyEditor") && (int)f.Tag == index)
                    return true;
            }
            return false;
        }

        public static bool FormOpen (string formName, int tag = 1)
        {
            foreach (Form f in list)
            {
                if (formName.Equals(f.Name) && tag == (int)f.Tag)
                    return true;
            }

            return false;
        }

        public static bool FormOpen(Form o, int tag = 1)
        {
            foreach (Form f in list)
            {
                if (o.Name == f.Name && tag == (int)f.Tag)
                    return true;
            }

            return false;
        }

        public static Form GetForm(Form o, int tag = 1)
        {
            foreach (Form f in list )
            {
                if (o.Name == f.Name && tag == (int)f.Tag)
                    return f;
            }
            return null;
        }

        public static Form GetForm(string frmName, int tag = 1)
        {
            foreach (Form f in list)
            {
                if (frmName == f.Name && tag == (int)f.Tag)
                    return f;
            }
            return null;
        }

        public static int Add(Form o)
        {
            FormAdded?.Invoke(null, new FormAddedEventArgs() { form = o, key = o.Name + o.Tag.ToString() });
            return list.Add(o);
        }

        public static int AddPopup(Form o)
        {
            PopupAdded?.Invoke(null, new FormPopupAddedEventArgs() { form = o, key = o.Name + o.Tag.ToString() });
            return list.Add(o);
        }

        public static void Remove(Form o)
        {
            try
            {
                FormRemoved?.Invoke(null, new FormRemovedEventArgs() { formName = o.Name, key = o.Name + o.Tag.ToString() });
                list.Remove(o);
    
            }catch (Exception)
            {

            }
            
        }

        public static void RemovePopup(Form o)
        {
            try
            {
                PopupRemoved?.Invoke(null, new FormPopupRemovedEventArgs() { formName = o.Name, key = o.Name + o.Tag.ToString() });
                list.Remove(o);

            }
            catch (Exception)
            {

            }

        }

        public static bool Close()
        {
            int nCount = list.Count;
            while (list.Count > 0)
            {
                ((Form)list[0]).Close();
                if (list.Count == nCount)
                    return false;
                else
                    nCount = list.Count;
            }

            return true;
        }
        #endregion

        #region Properties
        public static ArrayList List
        {
            get { return list; }
        }
        #endregion
    }

    public class FormRemovedEventArgs : EventArgs
    {
        public string formName { get; set; }
        public string key { get; set; }
        
    }

    public class FormAddedEventArgs : EventArgs
    {
        public Form form { get; set; }
        public string key { get; set; }

    }

    public class FormPopupRemovedEventArgs : EventArgs
    {
        public string formName { get; set; }
        public string key { get; set; }

    }

    public class FormPopupAddedEventArgs : EventArgs
    {
        public Form form { get; set; }
        public string key { get; set; }

    }
}
