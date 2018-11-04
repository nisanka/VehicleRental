﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using VehicleRentalUI.Enum;
using VehicleRentalUI.Models;

namespace VehicleRentalUI.Helpers
{
    public class AttachmentHelper
    {
        public Attachment SaveAttachment(HttpPostedFileBase file, string Id, AttachmentType AttachmentType)
        {
            var result = new Attachment();
            if(file != null && file.ContentLength > 0)
            {
                var folderPath = Path.Combine(GetContentPath(AttachmentType, Id));
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = GetAutoGeneratedFileName(file.FileName);
                var path = Path.Combine(folderPath, fileName);

                file.SaveAs(path);
                result.AttachmentType = AttachmentType;
                result.FileName = path;
                result.OriginalFileName = file.FileName;  
            }

            return result;
        }

        public List<Attachment> SaveAttachments(HttpPostedFileBase[] files, AttachmentType AttachmentType, string Id)
        {
            var result = new List<Attachment>();
            foreach(var file in files)
            {
                var savedAttachment = SaveAttachment(file, Id, AttachmentType);
                if (!string.IsNullOrEmpty(savedAttachment.FileName))
                    result.Add(savedAttachment);
            }

            return result;
        }

        private string GetContentPath(AttachmentType AttachmentType, string Id)
        {
            string basePath = ConfigurationManager.AppSettings["ContentPath"] ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VehiclRentalContent");
            //string basePath = "Content";

            string subPath;
            switch (AttachmentType)
            {
                case AttachmentType.None:
                    subPath = "None";
                    break;
                case AttachmentType.Customer:
                    subPath = "Customer" + (string.IsNullOrEmpty(Id) ? "" : "\\"+Id );
                    break;
                case AttachmentType.Vehicle:
                    subPath = "Vehicle" + (string.IsNullOrEmpty(Id) ? "" : "\\" + Id); ;
                    break;
                case AttachmentType.Reservation:
                    subPath = "Reservation" + (string.IsNullOrEmpty(Id) ? "" : "\\" + Id); ;
                    break;
                case AttachmentType.Brand:
                    subPath = "Brand";
                    break;
                default:
                    subPath = "None";
                    break;
            }

            return Path.Combine(basePath, subPath);
        }

        private string GetAutoGeneratedFileName(string filename)
        {
            return string.Concat(DateTime.Now.ToFileTime().ToString(), Path.GetExtension(filename));
        }        
    }
}