import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '@app/models/Evento';
import { EventoService } from '@app/services/evento.service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {
  modalRef: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public widthImg : number = 100;
  public marginImg : number = 2;
  public mostrarImagem: boolean = true;
  private filtroListado : string = "";

  public get filtroLista() : string
  {
    return this.filtroListado;
  }

  public set filtroLista(value: string)
  {
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroLista ?
      this.filtrarEventos(this.filtroLista):
      this.eventos;
  }

  public filtrarEventos(filtrarPor: string) : Evento[]
  {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
              evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
              );
  }

  constructor(
    private eventoService : EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router:Router
    ) { }

  public ngOnInit() : void {
    /** spinner starts on init */
    this.spinner.show()
    this.getEventos();
  }

  public getEventos():void
  {
    this.eventoService.getEventos().subscribe({
      next: (eventos : Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },

      error: (error : Error) => {
        this.spinner.hide(),
        this.toastr.error('Erro ao carregar os Eventos!', 'Erro')
      },

      complete: () => this.spinner.hide()
    });
  }

  public alterarImagem():void
  {
      this.mostrarImagem = !this.mostrarImagem;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.toastr.success('Evento Deletado!', 'Efetuado');
    this.modalRef.hide();
  }

  decline(): void {
    this.toastr.info('Nada foi alterado!', 'Cancelado');
    this.modalRef.hide();
  }

  detalheEvento(id:number) {
    this.router.navigate([`/eventos/detalhe/${id}`]);
  }
}
