    /*==================================================================
    [ User ]*/
    
    $('#toggleLoginPassword, #toggleRegisterPassword, #toggleConfirmRegisterPassword, #togglePassword').on('click', function(element)
    {
        var input = $(this).attr('data-input')
        var button = $(this).attr('data-button')
        togglePassword(input,button)
    })

   
    function togglePassword(input,button)
    {
        if ($('#'+input).prop('type') == 'password') 
        {
            $('#'+input).prop('type', 'text')
            $('#'+button).html('<i class="fa-solid fa-eye-slash"></i>')
        }
        else 
        {
            $('#'+input).prop('type', 'password')
            $('#'+button).html('<i class="fa-solid fa-eye"></i>')
        }
    }

    $('#term_condition').is(':checked') 
    {
        if$('#term_condition').is(':checked') == true

    }