package be.pxl.backend.services;

import be.pxl.backend.exceptions.SessionException;
import be.pxl.backend.models.AcceleroMeter;
import be.pxl.backend.models.Session;
import be.pxl.backend.repositories.SessionRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;

import java.util.*;

/**
 * Created by Jonas on 14/10/16.
 */
@Service
public class SessionService {

    @Autowired
    private SessionRepository sessionRepository;

    public Session startSession(Session session) {
        if (session.getStart() != null && session.getEnd() == null) {
            return sessionRepository.save(session);
        } else {
            throw new SessionException("Session start cannot be null and Session end must be null!");
        }
    }

    public Session stopSession(Session session) {
        if (session.getStart() != null && session.getEnd() != null) {
            return sessionRepository.save(session);
        } else {
            throw new SessionException("Session start cannot be null and Session end cannot be null!");
        }
    }

    public Session getSessionById(int id) {
        return sessionRepository.findOne(id);
    }

    public List<Session> getAllSessions(String username) {
        return sessionRepository.getAllSessions(username);
    }

    public Map<String, Double> getAverages(int id) {
        Session session = getSessionById(id);
        Map<String, Double> dictionary = new HashMap<>();

        OptionalDouble avgTemp = session.getTemperatures().stream().mapToDouble(t -> t.getTemperature()).average();
        if (avgTemp.isPresent()) {
            dictionary.put("AverageTemperature", avgTemp.getAsDouble());
        }

        OptionalDouble avgHumidity = session.getHumidities().stream().mapToDouble(h -> h.getHumidity()).average();
        if(avgHumidity.isPresent()) {
            dictionary.put("AverageHumidity", avgHumidity.getAsDouble());
        }

        OptionalDouble avgPressure = session.getPressures().stream().mapToDouble(p -> p.getPressure()).average();
        if(avgPressure.isPresent()) {
            dictionary.put("AveragePressure", avgPressure.getAsDouble());
        }

        List<AcceleroMeter> acceleroMeters = session.getAcceleroMeters();

        return dictionary;
    }

}
