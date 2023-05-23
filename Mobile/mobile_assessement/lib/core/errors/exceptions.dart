class ServerException implements Exception {
  final String message;

  ServerException(this.message);
}

class CacheException implements Exception {
  final String message;

  CacheException(this.message);
}

class WeatherNotFoundException implements Exception {
  final String message;

  WeatherNotFoundException(this.message);
}

class InputException implements Exception {
  final String message;

  InputException(this.message);
}
