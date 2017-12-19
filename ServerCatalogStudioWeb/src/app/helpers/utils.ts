declare var $: any;

export module helpers {
  export function isNull(objeto: any): boolean {
    return objeto == null || objeto == undefined;
  }

  export function isNullEmptyOrWhiteSpace(texto: string): boolean {
    if (isNull(texto)) {
      return true;
    }
    return texto == "" || texto == " ";
  }
}
