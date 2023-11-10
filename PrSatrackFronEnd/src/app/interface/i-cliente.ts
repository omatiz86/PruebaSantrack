export interface ICliente {
    idcliente?:number | null,
    nombre: string;
    tipoDocumento: string;
    documento: number;
    nit: string;
    tipoCliente: string;
    telefonoContacto: string;
    fechaNacimiento: Date;
    direccion: string;
    idUbicacion: string;
    correoElectronico: string;
    genero: string;
    notas: string;

}
