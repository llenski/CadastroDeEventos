import { Evento } from "./Evento";
import { RedeSocial } from "./RedesSocial";

export interface Palestrante
{
  id :  number;
  nome :  string;
  miniCurriculo :  string;
  imagemUrl :  string;
  telefone :  string;
  email :  string;
  redesSociais :  RedeSocial[];
  palestrantesEventos : Evento[];
}
