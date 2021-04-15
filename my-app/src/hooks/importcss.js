// import "../Components/ComponentCss/";
export default function importcss(path,style){
   
   path= path.toLowerCase();
   const windowpa=window?.location.pathname.toLocaleLowerCase();
   
    if (windowpa.includes( `${path}`) )
   require(`../Components/ComponentCss/${style}`)
}