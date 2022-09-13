import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form: FormGroup;

  //Atalho parapuxar o FormField
  get f() : any{
    return this.form.controls;
  }

  OnSubmit():void{
    //Para e Retorna se stiver invalido
    if(this.form.invalid)
    {
      return;
    }
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
  }
  public validation():any{
    const formOptions : AbstractControlOptions = {
      validators : ValidatorField.mustMatch('senha', 'cSenha')
    };

    this.form = this.fb.group({
      titulo : ["", Validators.required],
      pNome : ["", [Validators.required, Validators.maxLength(50), Validators.minLength(4)]],
      uNome : ["", [Validators.required, Validators.maxLength(50), Validators.minLength(4)]],
      email : ["", [Validators.required, Validators.email]],
      telefone : ["", Validators.required],
      funcao : ["", Validators.required],
      descricao : ["", [Validators.required, Validators.maxLength(200), Validators.minLength(5)]],
      senha : ["", [Validators.required, Validators.minLength(3)]],
      cSenha : ["", Validators.required]
    }, formOptions);
  }
  public resetForm(event: any) : any{
    event.preventDefault();
    this.form.reset();
  }
}
