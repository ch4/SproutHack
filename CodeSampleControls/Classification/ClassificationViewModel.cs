using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCsSample.CodeSampleControls.Classification
{
    public class ClassificationViewModel
    {

        private ClassificationObject _root;
        private readonly ObservableCollection<ClassificationObject> _itemCollection = new ObservableCollection<ClassificationObject>();

        public ClassificationObject Root
        {
            get { return _root; }
            set
            {
                if (Equals(value, _root)) return;
                _root = value;
            }
        }

        public ObservableCollection<ClassificationObject> ItemCollection
        {
            get { return _itemCollection; }
        }
    }
}
