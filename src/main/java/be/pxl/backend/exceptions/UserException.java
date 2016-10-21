package be.pxl.backend.exceptions;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

/**
 * Created by Jonas on 21/10/16.
 */

@ResponseStatus(value = HttpStatus.NOT_ACCEPTABLE, reason = "Password error")
public class UserException extends RuntimeException {
}
