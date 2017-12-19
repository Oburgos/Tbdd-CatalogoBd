export interface ICrudModelBase {
    id: number;
    descripcion:string;
    activo:boolean;
};

export const CRUD_TIPO = {
    SistemasOperativos:"sistemas-operativos",
    Ambientes: "ambientes",
    MotoresBasesDeDatos: "motores-bdd"
};