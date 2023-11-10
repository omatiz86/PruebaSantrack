export interface IdataUno {
    idcliente: number;
    nombre: string;
    tipoDocumento: string;
    documento: number;
    nit: string | null;
    tipoCliente: string;
    telefonoContacto: string;
    fechaNacimiento: Date;
    direccion: string;
    idUbicacion: string;
    correoElectronico: string;
    género: string;
    notas: string | null;    
}

export interface IUbicaciones {
    idUbicacion: number| null;
    codDivipola: string| null;
    descripcion: string| null; 
          
}

