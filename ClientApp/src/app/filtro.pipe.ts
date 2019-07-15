import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filtro'
})
export class FiltroPipe implements PipeTransform {

  transform(value: any, arg: any): any {
    if(arg == '') return value;
  const filterPost = [];
  for(const post of value ){
    if(post.cliente_nombre1.toLowerCase().indexOf(arg.toLowerCase() ) > -1){
      filterPost.push(post);
    }
  }
  return filterPost;
  }

}
