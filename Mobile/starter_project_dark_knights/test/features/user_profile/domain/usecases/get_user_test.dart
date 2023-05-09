import 'dart:ffi';

import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_user.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'get_user_test.mocks.dart';

@GenerateMocks([UserRepository])
void main(){
    
    setUp(() {
final mockUserRepository = MockUserRepository();
final usecase = GetUser(mockUserRepository);
    });
    final user = UserEntity(id: "user_123", username: "@jhon", firstName: "jhon", lastName:"abe", occupation: "designer", selfDescription: "I love design", password: "123", image: "someUrl");
    test(
      'should get user details',
      ()async{
        final mockUserRepository = MockUserRepository();
final usecase = GetUser(mockUserRepository);
when(mockUserRepository.getUser("user_123")).thenAnswer((_) async => Right(user));

final result = await usecase( Params(id: "user_123"));

expect(result,Right(user));
verify(mockUserRepository.getUser("user_123"));
verifyNoMoreInteractions(mockUserRepository);
      }
    );
 
}



