import { Producto } from './producto';
import { MaestraFactura } from './maestra-factura';

export class FacturaDetalle {
    detalle_id: string;
    detalle_cantidad: number;
    detalle_precio_ven : number;
    detalle_fecha_det: Date;
    detalle_subtotal : number; 
	detalle_cod_factura : string;
    detalle_cod_producto : string;
    producto : Producto;
    facturaMaestro:MaestraFactura;
}
