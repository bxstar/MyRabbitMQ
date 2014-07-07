﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace MyRabbitMQ.Consumer
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Person")]
    public partial class Person : global::ProtoBuf.IExtensible
    {
        public Person() { }

        private int _id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _email = "";
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"email", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
