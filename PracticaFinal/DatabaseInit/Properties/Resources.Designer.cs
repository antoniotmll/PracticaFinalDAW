﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseInit.Properties {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DatabaseInit.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELIMITER &apos;//&apos;
        ///DROP DATABASE IF EXISTS cochesdaw //
        ///CREATE DATABASE cochesdaw //
        ///
        ///CREATE TABLE cochesdaw.usuario(
        ///id INT NOT NULL AUTO_INCREMENT,
        ///usuario VARCHAR(50) NOT NULL,
        ///passwd VARCHAR(1024) NOT NULL,
        ///tipoUsuario VARCHAR (10) NOT NULL,
        ///nombre VARCHAR(50),
        ///direccion VARCHAR(200),
        ///telefono VARCHAR(20),
        ///PRIMARY KEY(id)
        ///)ENGINE = INNODB;//
        ///
        ///CREATE TABLE cochesdaw.coche(
        ///id INT NOT NULL AUTO_INCREMENT,
        ///nombre VARCHAR(50) NOT NULL,
        ///descripcion VARCHAR(500) NOT NULL,
        ///marca VARCHAR(20) NOT  [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string generatedb {
            get {
                return ResourceManager.GetString("generatedb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELIMITER &apos;//&apos;
        ///INSERT INTO cochesdaw.usuario
        ///(id, usuario, passwd, tipoUsuario, nombre, direccion, telefono)
        ///VALUES
        ///(NULL, &apos;JuanitoX&apos;, &apos;secret&apos;, &apos;user&apos;, &apos;Juan Perez&apos;, &apos;dir eccion&apos;, &apos;01234&apos;),
        ///(NULL, &apos;mariavergara19&apos;, &apos;supersecret&apos;, &apos;user&apos;, &apos;Maria Vergara&apos;, &apos;dir accion&apos;, &apos;04321&apos;),
        ///(NULL, &apos;xXsuperadminXx&apos;, &apos;cringelord&apos;, &apos;admin&apos;, &apos;Juan Nieves&apos;, &apos;dir rid&apos;, &apos;00000&apos;)
        /////
        ///INSERT INTO cochesdaw.coche
        ///(id, nombre, descripcion, marca, modelo, motor, anyo, precio, img)
        ///VALUES
        ///(NULL, &apos;FIAT 500&apos;, &apos;FIAT pequenyo [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string insertdummydata {
            get {
                return ResourceManager.GetString("insertdummydata", resourceCulture);
            }
        }
    }
}