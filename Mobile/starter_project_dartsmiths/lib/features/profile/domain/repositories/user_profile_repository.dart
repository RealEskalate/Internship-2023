import 'package:dartz/dartz.dart';

import '../../../../core/error/profile_failures.dart';
import '../entities/user_profile.dart';

abstract class UserProfileRepository {
  Future<Either<Failure, UserProfile>> getUserProfile(String id);
}
