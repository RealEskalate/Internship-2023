import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartz/dartz.dart';
import '../entities/user_profile.dart';

abstract class UserProfileRepository {
  Future<Either<Failure, UserProfile>> getUserProfile(String id);
}
