using System.Collections;


namespace CurseCase
{
    public class Suspects
    {
        private Tuple<string, int>[] data;
        public Tuple<string, int>[] Data
        {
            get => data;
            set => data = value;
        }

        // TODO
        public Suspects(GenTree tree, int size)
        {
            this.data = new Tuple<string, int>[size];
            Queue fila = new Queue();
            fila.Enqueue(tree);
            int counter = 0;
            while (fila.Count != 0)
            {
                GenTree a = (GenTree) fila.Dequeue();
                if (a.Left != null) fila.Enqueue(a.Left);
                if (a.Right != null) fila.Enqueue(a.Right);
                this.data[counter] = Tuple.Create(a.Name, a.Suspicion);
                counter+=1;
            }
        }

        static void HeapSortConcrete(Tuple<string, int>[] myTuple, int dataLength, int i) {
            int TheBig = i;
            int another = 2*i + 2;
            int one = 2*i + 1;
            if (one < dataLength && myTuple[one].Item2 < myTuple[TheBig].Item2) TheBig = one;
            if (another < dataLength && myTuple[another].Item2 < myTuple[TheBig].Item2) TheBig = another;
            if (TheBig != i) 
            {
                Tuple<string, int> tupleToMove = myTuple[i];
                myTuple[i] = myTuple[TheBig];
                myTuple[TheBig] = tupleToMove;
                HeapSortConcrete(myTuple, dataLength, TheBig);
            }
        }
        
        // TODO
        public void HeapSort()
        {
            var dataLength = this.data.Length;
            for (int i = dataLength / 2 - 1; i >= 0; i--)
            {
                HeapSortConcrete(this.data, dataLength, i);
            }
            for (int i = dataLength-1; i>=0; i--) 
            {
                Tuple<string, int> thefirst = this.data[0];
                this.data[0] = this.data[i];
                this.data[i] = thefirst;
                HeapSortConcrete(data, i, 0);
            }
        }

        // Utilitary method to print the array.
        public override string ToString()
        {
            return string.Join<Tuple<string, int>>(" | ", this.data);
        }
    }
}
