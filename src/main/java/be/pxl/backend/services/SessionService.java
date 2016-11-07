package be.pxl.backend.services;

import be.pxl.backend.exceptions.SessionException;
import be.pxl.backend.models.AcceleroMeter;
import be.pxl.backend.models.Session;
import be.pxl.backend.repositories.SessionRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.expression.spel.ast.FloatLiteral;
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

    public void setSessionRepository(SessionRepository sessionRepository) {
        this.sessionRepository = sessionRepository;
    }

    public Session startSession(Session session) {
        if (session.getStart() != null && session.getEnd() == null) {
            return sessionRepository.save(session);
        } else {
            throw new SessionException("Session start cannot be null and Session end must be null!");
        }
    }

    public Session stopSession(Session session) {
        if (session.getStart() == null && session.getEnd() == null) {
            throw new SessionException("Session start cannot be null and Session end cannot be null!");
        } else if (session.getEnd().before(session.getStart())) {
            throw new SessionException("Session end must me after Session start");
        } else {
            return sessionRepository.save(session);
        }
    }

    public Session getSessionById(int id) {
        return sessionRepository.findOne(id);
    }

    public List<Session> getAllSessions(String username) {
        return sessionRepository.getAllSessions(username);
    }

    public void deleteSessionForId(int id) {
        sessionRepository.delete(id);
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
        double activity = activity(acceleroMeters);
        dictionary.put("AverageActivity", activity);

        return dictionary;
    }

    private double activity(List<AcceleroMeter> acceleroMeters) {
        double activity = 0.0;
        for(AcceleroMeter acceleroMeter: acceleroMeters) {
            double temp = 0.0;
        }
        return activity / (float)acceleroMeters.size();
    }

}
