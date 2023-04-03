import { AbstractControl, FormControl, FormGroup } from "@angular/forms";

export class FormValidator {
  static argsCompare(arg: string, argConfirm: string): any {
    return (group: AbstractControl): any => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[arg];
      const matchingControl = formGroup.controls[argConfirm];

      if (matchingControl.errors && !matchingControl.errors['mustMatch']) {
        return null;
      }
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({mustMatch: true})
      } else {
        matchingControl.setErrors(null);
      }
    }
  }

  static checkFieldsWhithError(nomeCampo: FormControl): any {
    return { 'is-invalid': nomeCampo.errors && nomeCampo.touched };
  }

  static returnMessage(nomeCampo: FormControl, elementoCampo: string): any {
    if (nomeCampo.errors?.["required"])
      return `Este campo é obrigatório.`;

    if (nomeCampo.errors?.["minlength"])
      return `Este campo deve conter no mínimo ${nomeCampo.errors?.["minlength"].requiredLength} caracteres`;

    if (nomeCampo.errors?.["maxlength"])
      return `Este campo deve conter no máximo ${nomeCampo.errors?.["maxlength"].requiredLength} caracteres`;

    if (nomeCampo.errors?.["max"])
      return `Este campo está limitado a ${nomeCampo.errors?.["max"].max} unidades.`;

    if (nomeCampo.errors?.["email"])
      return `Este campo está inválido`;

    if (elementoCampo == "Confirmar Senha")
      {
        if (nomeCampo.errors)
          return 'Confirmação de senha inválida';
      }

    return null;
  }

}
