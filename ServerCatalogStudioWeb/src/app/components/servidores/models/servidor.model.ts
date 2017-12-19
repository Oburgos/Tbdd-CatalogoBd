import { ServidorConexion } from "app/components/servidores/models/servidor.conexion";

export class Servidor {
    id: number = 0;
    descripcion: string = "";
    ambienteId: number = 0;
    sistemaOperativoId: number = 0;
    configuracion = new ServidorConexion();
    cores: number = 1;
    ram: number = 1;
    almacenamiento: number = 1;
}