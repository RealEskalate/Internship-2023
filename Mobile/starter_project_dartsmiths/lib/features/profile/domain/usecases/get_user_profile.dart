import 'package:dartz/dartz.dart';

import '../../../../core/error/profile_failures.dart';
import '../entities/user_profile.dart';
import '../repositories/user_profile_repository.dart';

class GetUserProfile {
  final UserProfileRepository repository;

  GetUserProfile(this.repository);

  Future<Either<Failure, UserProfile>> execute({
    required Object id,
  }) async {
    return repository.getUserProfile(id);
  }
}
