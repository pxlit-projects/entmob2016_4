package be.pxl.backend.exceptions;

/**
 * Created by Jonas on 21/10/16.
 */

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.NOT_ACCEPTABLE, reason = "Values are out of range: min 0G and max 250G")
public class AcceleroMeterException extends RuntimeException {
}
