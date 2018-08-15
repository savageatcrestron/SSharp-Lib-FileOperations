namespace FileOperations;
        // class declarations
         class FileOps;
         class Car;
         class RootObject;
     class FileOps 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION readAFile ( STRING folderLocation , STRING FileName );
        STRING_FUNCTION hiJason ( STRING sourceLocation , STRING sourceName );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class Car 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING brand[];
        STRING year[];
        STRING model[];
    };

     class RootObject 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

