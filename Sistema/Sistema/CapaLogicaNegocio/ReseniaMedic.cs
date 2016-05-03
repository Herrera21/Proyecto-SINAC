using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class ReseniaMedic
    {
        private bool internado;
        private string motivoIN;
        private bool tratMedic;
        private string motivoTM;
        private bool lentCont;
        private string motivoLC;
        private bool operado;
        private string motivoOP;
        private bool limitFisic;
        private string tipoLimitFisic;
        private bool checkMedic;
        private string diagnostico;
        private string tipoSangre;

        public ReseniaMedic() { }

        public ReseniaMedic(bool internado, string motivoIN, bool tratMedic, string motivoTM, bool lentCont, string motivoLC,
            bool operado, string motivoOP, bool limitFisic, string tipoLimitFisic, bool checkMedic, string diagnostico, string tipoSangre)
        {
            this.internado = internado;
            this.motivoIN = motivoIN;
            this.tratMedic = tratMedic;
            this.motivoTM = motivoTM;
            this.lentCont = lentCont;
            this.motivoLC = motivoLC;
            this.operado = operado;
            this.motivoOP = motivoOP;
            this.limitFisic = limitFisic;
            this.tipoLimitFisic = tipoLimitFisic;
            this.checkMedic = checkMedic;
            this.diagnostico = diagnostico;
            this.tipoSangre = tipoSangre;
        }

        public void setInternado(bool internado)
        {
            this.internado = internado;
        }

        public bool getInternado()
        {
            return internado;
        }

        public void setMotivoIN(string motivoIN)
        {
            this.motivoIN = motivoIN;
        }

        public string getMotivoIN()
        {
            return motivoIN;
        }

        public void setTratMedic(bool tratMedic)
        {
            this.tratMedic = tratMedic;
        }

        public bool getTratMedic()
        {
            return tratMedic;
        }

        public void setMotivoTM(string motivoTM)
        {
            this.motivoTM = motivoTM;
        }

        public string getMotivoTM()
        {
            return motivoTM;
        }

        public void setLentCont(bool lentCont)
        {
            this.lentCont = lentCont;
        }

        public bool getLentCont()
        {
            return lentCont;
        }

        public void setMotivoLC(string motivoLC)
        {
            this.motivoLC = motivoLC;
        }

        public string getMotivoLC()
        {
            return motivoLC;
        }

        public void setOperado(bool operado)
        {
            this.operado = operado;
        }

        public bool getOperado()
        {
            return operado;
        }

        public void setMotivoOP(string motivoOP)
        {
            this.motivoOP = motivoOP;
        }

        public string getMotivoOP()
        {
            return motivoOP;
        }

        public void setLimitFisic(bool limitFisic)
        {
            this.limitFisic = limitFisic;
        }

        public bool getLimitFisic()
        {
            return limitFisic;
        }

        public void setTipoLimitFisic(string tipoLimitFisic)
        {
            this.tipoLimitFisic = tipoLimitFisic;
        }

        public string getTipoLimitFisic()
        {
            return tipoLimitFisic;
        }

        public void setCheckMedic(bool checkMedic)
        {
            this.checkMedic = checkMedic;
        }

        public bool getCheckMedic()
        {
            return checkMedic;
        }

        public void setDiagnostico(string diagnostico)
        {
            this.diagnostico = diagnostico;
        }

        public string getDiagnostico()
        {
            return diagnostico;
        }

        public void setTipoSangre(string tipoSangre)
        {
            this.tipoSangre = tipoSangre;
        }

        public string getTipoSangre()
        {
            return tipoSangre;
        }
    }
}