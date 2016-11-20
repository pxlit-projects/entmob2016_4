package be.pxl.backend.exceptions;

/**
 * Created by Jonas on 21/10/16.
 */

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.NOT_ACCEPTABLE, reason = "Session Error")
public class SessionException extends RuntimeException {

    public SessionException(String message) {
        super(message);
    }

}
