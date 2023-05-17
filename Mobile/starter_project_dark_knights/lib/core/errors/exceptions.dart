class ServerException implements Exception {
  final String message;

  ServerException(this.message);
}

class CacheException implements Exception {
  final String message;

  CacheException(this.message);
}

class UserNotFoundException implements Exception{
  final String message;

  UserNotFoundException(this.message);
  
}
