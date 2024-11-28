import { showLoading, hideLoading } from "./loadingUtils.js";
import { showSuccessAlert, showErrorAlert } from "./alertUtils.js"

export async function handleForm(submitAction, closeModalAction, loadIcon){
    
    showLoading(loadIcon);
      
    setTimeout(async () => {
        try {
            
            const message = await submitAction();
            
            
            hideLoading(loadIcon);
            showSuccessAlert(message);
           

            setTimeout(() => {
                
                closeModalAction();
            }, 2000);
        } catch (error) {
            
            hideLoading(loadIcon);
            showErrorAlert(error.message);
        }
    }, 2000);
}