using System;

namespace PaintDefectDetectionSystem.Model
{
    public class Car
    {
        private int id;
        private string bodyNo;
        private string cameraId;
        private String defectPos;
        private DateTime ts;

        public int Id
        {
            get => id;
            set
            {
                if (value == id)
                    return;
                id = value;
                //  OnPropertyChanged();
            }
        }

        public string BodyNo
        {
            get => bodyNo;
            set
            {
                if (value == bodyNo)
                    return;
                bodyNo = value;
                //OnPropertyChanged();
            }
        }

        public string CameraId
        {
            get => cameraId;
            set
            {
                if (value == cameraId)
                    return;
                cameraId = value ?? throw new ArgumentNullException(nameof(value));
                //OnPropertyChanged();
            }
        }

        public string DefectPos
        {
            get => defectPos;
            set
            {
                if (value == defectPos)
                    return;
                defectPos = value ?? throw new ArgumentNullException(nameof(value));
                //OnPropertyChanged();
            }
        }

        public DateTime Ts
        {
            get => ts;
            set
            {
                if (value == ts)
                    return;
                ts = value;
                //OnPropertyChanged();
            }
        }

        public Car(int id, string bodyNo, string cameraId, string defectPos, DateTime ts)
        {
            Id = id;
            BodyNo = bodyNo;
            CameraId = cameraId;
            DefectPos = defectPos;
            Ts = ts;
        }

        public Car()
        {
        }

        public override string ToString()
        {
            return $"Id = {Id},defectPos = {defectPos}";
        }
    }
}