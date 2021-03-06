﻿using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
   public class VehicleDTO
    {
        public VehicleDTO(int iD, string carBoard, EVehicleType type, ModelDTO model, int modelID, bool isActive)
        {
            ID = iD;
            CarBoard = carBoard;
            Type = type;
            Model = model;
            ModelID = modelID;
            IsActive = isActive;
        }
        public VehicleDTO()
        {

        }

        public int ID { get; set; }
        // public int IDCliente { get; set; }
        public string CarBoard { get; set; }
        public EVehicleType Type { get; set; }
        public ModelDTO Model { get; set; }
        public int ModelID { get; set; }
        public bool IsActive { get; set; }
    }
}
