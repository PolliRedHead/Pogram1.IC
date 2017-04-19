// Type: iofile.worker
// Assembly: iofile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Рафаэль\Desktop\Архитектура ИС\Лаба 1\Example\iofile.exe

using System;

namespace iofile
{
     class Plane
    {
        public string _From;
        public string _Where;
        public string _PlaneName;
        public int _Hours;
        public string _WorkingStatus;

        public Plane()
        {
            this._From = "";
            this._Where = "";
            this._PlaneName = "";
            this._Hours = 0;
            this._WorkingStatus = "";
        }

        public Plane(string From, string Where, string PlaneName, int Hours, string WorkingStatus)
        {
            this._From = From;
            this._Where = Where;
            this._PlaneName = PlaneName;
            this._Hours = Hours;
            this._WorkingStatus = WorkingStatus;
        }

        public void SetFrom(string From)
        {
            this._From = From;
        }

        public void SetWhere(string Where)
        {
            this._Where = Where;
        }

        public void SetPlaneName(string PlaneName)
        {
            this._PlaneName = PlaneName;
        }

        public void SetHours(int Hours)
        {
            this._Hours = Hours;
        }

        public void SetWorkingStatus(string WorkingStatus)
        {
            this._WorkingStatus = WorkingStatus;
        }

        public string GetFrom()
        {
            return this._From;
        }

        public string GetWhere()
        {
            return this._Where;
        }

        public string GetPlaneName()
        {
            return this._PlaneName;
        }

        public int GetHours()
        {
            return this._Hours;
        }

        public string GetWorkingStatus()
        {
            return this._WorkingStatus;
        }

        public void PrintPlane()
        {
            Console.WriteLine(this.GetFrom() + " " + this.GetWhere() + " " + this.GetPlaneName() + " " + this.GetHours().ToString() + " " + this.GetWorkingStatus());
        }
    }
}
