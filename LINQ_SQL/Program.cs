using LINQ_SQL;
using (var context = new MiDataContext())
{
    
    try
    {
        Console.WriteLine("########################################################");
        var productos = context.Producto.ToList();
        Console.WriteLine("Conexión exitosa. Número de productos: " + productos.Count);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
    }
    try
    {
        Console.WriteLine("########################################################");
        var nuevoProducto = new Producto
        {
            Nombre = "Nuevo Producto",
            Precio = 150,
            Categoria = "Nuevo",
            Estado = true
        };
        context.Producto.Add(nuevoProducto);
        context.SaveChanges();
        Console.WriteLine("Producto Creado", nuevoProducto.ProductoID);
        // Actualizar un producto existente
        /*var productoExistente = context.Producto.FirstOrDefault(p => p.ProductoID == nuevoProducto.ProductoID);
        if (productoExistente != null)
        {
            productoExistente.Precio = 200;
            context.SaveChanges();
        }

        // Eliminar un producto
        var productoAEliminar = context.Producto.FirstOrDefault(p => p.ProductoID == nuevoProducto.ProductoID);
        if (productoAEliminar != null)
        {
            context.Producto.Remove(productoAEliminar);
            context.SaveChanges();
        }*/
    }
    catch (Exception ex) {
        Console.WriteLine("Error al crear un nuevo producto: " + ex.Message);
    }
    try
    {
        // Consultar productos caros
        var productosCaros = context.Producto
                              .Where(p => p.Precio > 100)
                              .ToList();
        Console.WriteLine("-----------------------------------------------------------");
        foreach (var producto in productosCaros)
        {
            Console.WriteLine($"{producto.Nombre} - {producto.Precio:C}");
        }
    }
    catch (Exception ex) {
        Console.WriteLine("Error al consultar la tabla Producto: " + ex.Message);
    }
   
}