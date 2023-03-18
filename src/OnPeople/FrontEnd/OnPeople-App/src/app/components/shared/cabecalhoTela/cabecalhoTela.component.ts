import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { faBuilding, faUsersViewfinder } from '@fortawesome/free-solid-svg-icons'
@Component({
  selector: 'app-cabecalhoTela',
  templateUrl: './cabecalhoTela.component.html',
  styleUrls: ['./cabecalhoTela.component.scss']
})
export class CabecalhoTelaComponent implements OnInit {

  public contaLogada = false;

  @Input() titulo: string | undefined;
  @Input() subTitulo = '	Xing Ling do Brasil';
  @Input() iconCabecalho = faBuilding;
  @Input() iconVisao = faUsersViewfinder;
  @Input() visao = 'Administrador';
  @Input() botaoListar = false;


  constructor(private router: Router) { }

  ngOnInit() {
  }

  public listar(): void {
    this.router.navigate([`/${this.titulo?.toLocaleLowerCase()}/lista`])
  }


  public showCabecalho(): boolean {
    return this.router.url !== '/contas/login'
  }
}
