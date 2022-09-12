import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  @Input() titulo :string;
  @Input() iconClass: string = 'fa fa-user';
  @Input() subTitulo: string = 'Desde 2022';
  @Input() botaoListar: boolean = false;

  constructor(private router : Router) {}

  ngOnInit() {
    // this.botaoListar = (this.titulo == 'Dashboard')? false :  //Sem Logica, direto no HTML
    //                     (this.titulo == 'Perfil') ? false : true;
  }
  listar (): void{
    this.router.navigate([`${this.titulo.toLocaleLowerCase()}/lista`]);
  }
}
