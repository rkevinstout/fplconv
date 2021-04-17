﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
[System.Xml.Serialization.XmlRootAttribute("flight-plan", Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1", IsNullable=false)]
public partial class FlightPlan_t {
    
    private string filedescriptionField;
    
    private Person_t authorField;
    
    private string linkField;
    
    private System.DateTime createdField;
    
    private bool createdFieldSpecified;
    
    private Waypoint_t[] waypointtableField;
    
    private Route_t routeField;
    
    private Extensions_t extensionsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("file-description")]
    public string filedescription {
        get {
            return this.filedescriptionField;
        }
        set {
            this.filedescriptionField = value;
        }
    }
    
    /// <remarks/>
    public Person_t author {
        get {
            return this.authorField;
        }
        set {
            this.authorField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string link {
        get {
            return this.linkField;
        }
        set {
            this.linkField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime created {
        get {
            return this.createdField;
        }
        set {
            this.createdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool createdSpecified {
        get {
            return this.createdFieldSpecified;
        }
        set {
            this.createdFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("waypoint-table")]
    [System.Xml.Serialization.XmlArrayItemAttribute("waypoint", IsNullable=false)]
    public Waypoint_t[] waypointtable {
        get {
            return this.waypointtableField;
        }
        set {
            this.waypointtableField = value;
        }
    }
    
    /// <remarks/>
    public Route_t route {
        get {
            return this.routeField;
        }
        set {
            this.routeField = value;
        }
    }
    
    /// <remarks/>
    public Extensions_t extensions {
        get {
            return this.extensionsField;
        }
        set {
            this.extensionsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
public partial class Person_t {
    
    private string authornameField;
    
    private Email_t emailField;
    
    private string linkField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("author-name")]
    public string authorname {
        get {
            return this.authornameField;
        }
        set {
            this.authornameField = value;
        }
    }
    
    /// <remarks/>
    public Email_t email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string link {
        get {
            return this.linkField;
        }
        set {
            this.linkField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
public partial class Email_t {
    
    private string idField;
    
    private string domainField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string domain {
        get {
            return this.domainField;
        }
        set {
            this.domainField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
public partial class RoutePoint_t {
    
    private string waypointidentifierField;
    
    private WaypointType_t waypointtypeField;
    
    private string waypointcountrycodeField;
    
    private Extensions_t extensionsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("waypoint-identifier")]
    public string waypointidentifier {
        get {
            return this.waypointidentifierField;
        }
        set {
            this.waypointidentifierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("waypoint-type")]
    public WaypointType_t waypointtype {
        get {
            return this.waypointtypeField;
        }
        set {
            this.waypointtypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("waypoint-country-code")]
    public string waypointcountrycode {
        get {
            return this.waypointcountrycodeField;
        }
        set {
            this.waypointcountrycodeField = value;
        }
    }
    
    /// <remarks/>
    public Extensions_t extensions {
        get {
            return this.extensionsField;
        }
        set {
            this.extensionsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
public enum WaypointType_t {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("USER WAYPOINT")]
    USERWAYPOINT,
    
    /// <remarks/>
    AIRPORT,
    
    /// <remarks/>
    NDB,
    
    /// <remarks/>
    VOR,
    
    /// <remarks/>
    INT,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("INT-VRP")]
    INTVRP,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
public partial class Extensions_t {
    
    private System.Xml.XmlElement[] anyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
public partial class Route_t {
    
    private string routenameField;
    
    private string routedescriptionField;
    
    private string flightplanindexField;
    
    private RoutePoint_t[] routepointField;
    
    private Extensions_t extensionsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("route-name")]
    public string routename {
        get {
            return this.routenameField;
        }
        set {
            this.routenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("route-description")]
    public string routedescription {
        get {
            return this.routedescriptionField;
        }
        set {
            this.routedescriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("flight-plan-index", DataType="nonNegativeInteger")]
    public string flightplanindex {
        get {
            return this.flightplanindexField;
        }
        set {
            this.flightplanindexField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("route-point")]
    public RoutePoint_t[] routepoint {
        get {
            return this.routepointField;
        }
        set {
            this.routepointField = value;
        }
    }
    
    /// <remarks/>
    public Extensions_t extensions {
        get {
            return this.extensionsField;
        }
        set {
            this.extensionsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
public partial class Waypoint_t {
    
    private string identifierField;
    
    private WaypointType_t typeField;
    
    private string countrycodeField;
    
    private decimal latField;
    
    private decimal lonField;
    
    private string commentField;
    
    private decimal elevationField;
    
    private bool elevationFieldSpecified;
    
    private string waypointdescriptionField;
    
    private string symbolField;
    
    private Extensions_t extensionsField;
    
    /// <remarks/>
    public string identifier {
        get {
            return this.identifierField;
        }
        set {
            this.identifierField = value;
        }
    }
    
    /// <remarks/>
    public WaypointType_t type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("country-code")]
    public string countrycode {
        get {
            return this.countrycodeField;
        }
        set {
            this.countrycodeField = value;
        }
    }
    
    /// <remarks/>
    public decimal lat {
        get {
            return this.latField;
        }
        set {
            this.latField = value;
        }
    }
    
    /// <remarks/>
    public decimal lon {
        get {
            return this.lonField;
        }
        set {
            this.lonField = value;
        }
    }
    
    /// <remarks/>
    public string comment {
        get {
            return this.commentField;
        }
        set {
            this.commentField = value;
        }
    }
    
    /// <remarks/>
    public decimal elevation {
        get {
            return this.elevationField;
        }
        set {
            this.elevationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool elevationSpecified {
        get {
            return this.elevationFieldSpecified;
        }
        set {
            this.elevationFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("waypoint-description")]
    public string waypointdescription {
        get {
            return this.waypointdescriptionField;
        }
        set {
            this.waypointdescriptionField = value;
        }
    }
    
    /// <remarks/>
    public string symbol {
        get {
            return this.symbolField;
        }
        set {
            this.symbolField = value;
        }
    }
    
    /// <remarks/>
    public Extensions_t extensions {
        get {
            return this.extensionsField;
        }
        set {
            this.extensionsField = value;
        }
    }
}
