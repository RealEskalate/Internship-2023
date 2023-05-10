import 'dart:ffi';

import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_number_of_followers.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_user.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'get_user_test.mocks.dart';


void main(){
    
    setUp(() {
final mockUserRepository = MockUserRepository();
final usecase = GetNumberOfFollowing(mockUserRepository);
    });
    int   followersNumber = 5 ;
    test(
      'should get Number of following ',
      ()async{
        final mockUserRepository = MockUserRepository();
final usecase = GetNumberOfFollowing(mockUserRepository);
when(mockUserRepository.getNumberOfFollowing("user_123")).thenAnswer((_) async => Right(followersNumber) );

final result = await usecase( Params(id: "user_123"));

expect(result,Right(followersNumber));
verify(mockUserRepository.getNumberOfFollowing("user_123"));
verifyNoMoreInteractions(mockUserRepository);
      }
    );
    
 
}



