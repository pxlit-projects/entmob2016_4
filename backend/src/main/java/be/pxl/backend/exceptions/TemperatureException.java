package be.pxl.backend.exceptions;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

/**
 * Created by Jonas on 21/10/16.
 */

@ResponseStatus(value = HttpStatus.NOT_ACCEPTABLE, reason = "Temperature range must be between -50 and 50")
public class TemperatureException extends RuntimeException {
}
