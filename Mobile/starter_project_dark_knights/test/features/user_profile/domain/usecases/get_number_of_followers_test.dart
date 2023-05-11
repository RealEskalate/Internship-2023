import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_number_of_followers.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'create_user_test.mocks.dart';

void main() {
  late GetNumberOfFollowers usecase;
  late MockUserRepository mockUserRepository;

  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = GetNumberOfFollowers(mockUserRepository);
  });

  const String tId = "1";
  const int followers = 20;
  test("Should return the number of followers for the given user id", () async {
    when(mockUserRepository.getNumberOfFollowers(tId))
        .thenAnswer((_) async => const Right(followers));
    final result = await usecase(tId);

    expect(result, const Right(followers));
    verify(mockUserRepository.getNumberOfFollowers(tId));
    verifyNoMoreInteractions(mockUserRepository);
  });

  test(
      "Should return server failure when the the number of followers cannot be fetched.",
      () async {
    when(mockUserRepository.getNumberOfFollowers(tId))
        .thenAnswer((_) async => Left(ServerFailure("Internal Server Error")));

    final result = await usecase(tId);
    expect(result, Left(ServerFailure("Internal Server Error")));
    verify(mockUserRepository.getNumberOfFollowers(tId));
    verifyNoMoreInteractions(mockUserRepository);
  });
}
