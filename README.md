# MINICORE – Sistema de Comisiones

> App full-stack para gestionar vendedores, reglas de comisión, ventas y calcular comisiones.

---

## 🔍 Características

- CRUD de **Vendedores**  
- CRUD de **Reglas**  
- CRUD de **Ventas**  
- Cálculo de **Comisiones** por período

---

## 🚀 Enlaces de despliegue

- **API:** https://minicoreapiservice20250623191317.azurewebsites.net  
- **Frontend:** https://frontminicoregod.vercel.app/

---

## 🛠 Instalación local

```bash
# Clonar
git clone https://github.com/tu-usuario/minicore.git
cd minicore

# Backend
cd api
dotnet restore
dotnet ef database update
dotnet run

# Frontend
cd front
npm install
npm run dev

```
## 📑 Arquitectura MVC

Modelos: Vendedor, Regla, Venta  
Controladores: VendedoresController, ReglasController, VentasController, ComisionesController  
Servicio: ComisionService  
Vistas: interfaz en Next.js + Tailwind

---

## 🎥 Video explicativo

Ver explicación en YouTube (aquí iría tu enlace)

---

## 📬 Contacto

- **Email:** josesanchez200424@gmail.com  
- **GitHub:** https://github.com/FranSanz24
