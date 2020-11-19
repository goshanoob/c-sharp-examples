namespace RectWindowsForms
{
    class Presenter
    {
        private MainForm _form;
        private Rect _rect;
        public Presenter(MainForm form)
        {
            _form = form;
            //_form.SizeInsert += SizeInsertHandler;
        }
        
        private void SizeInsertHandler()
        {
        }

    }
}
