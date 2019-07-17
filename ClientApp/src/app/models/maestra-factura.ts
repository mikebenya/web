import { FacturaDetalle } from './FacturaDetalle';
import { Cliente } from './cliente';
import { Vendedor } from './vendedor';

export class MaestraFactura {
    maestro_id : string;
    maestro_fecha_fac : Date;
    maestro_total : Number;
    maestro_cc_cliente  : string;
    maestro_facDetalles:FacturaDetalle[];
    maestro_cc_vendedor : string;
    cliente:Cliente;
    vendedor:Vendedor;
    
}
