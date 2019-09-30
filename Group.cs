using System.Collections.Generic;

namespace l1
{

    public class Group
    {
        public List<Student> st { get; set; }
        public double avgMat { get; set; }
        public double avgPhy { get; set; }
        public double avgChem { get; set; }
        public double avgDraw { get; set; }
        public double avgAl{ get; set; }
        public double avgAvg { get; set; }
        public void result(){
            double avgM = 0;
            double avgP = 0;
            double avgC = 0;
            double avgD = 0;
            double avgA = 0;
            foreach (Student s in st) {
                avgM += s.mat;
                avgP += s.phy;
                avgC += s.chem;
                avgD += s.draw;
                avgA += s.al;
            }
            avgMat = avgM / st.Count;
            avgPhy = avgP / st.Count;
            avgChem = avgC / st.Count;
            avgDraw = avgD / st.Count;
            avgAl = avgA / st.Count;
            avgAvg = (avgMat + avgPhy + avgChem + avgDraw + avgAl) / 5;
        }
    }
}
