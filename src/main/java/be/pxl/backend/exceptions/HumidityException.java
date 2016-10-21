package be.pxl.backend.exceptions;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

/**
 * Created by Jonas on 21/10/16.
 */
@ResponseStatus(value = HttpStatus.NOT_ACCEPTABLE, reason = "Humdity value must be between 0.0 and 100.0")
public class HumidityException extends RuntimeException {
}
