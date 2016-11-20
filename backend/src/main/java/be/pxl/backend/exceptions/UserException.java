package be.pxl.backend.exceptions;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

/**
 * Created by Jonas on 21/10/16.
 */

@ResponseStatus(value = HttpStatus.NOT_ACCEPTABLE, reason = "Password cannot be emtpy and must be longer then 5 characters")
public class UserException extends RuntimeException {

    public UserException(String message) {
        super(message);
    }

}
