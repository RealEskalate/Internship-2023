import 'package:dark_knights/features/user_profile/domain/usecases/get_number_of_followers.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'get_followers_test.mocks.dart';

void main(){
  late MockUserRepository mockUserRepository;
  late GetNumberOfFollowing usecase;
    
    setUp(() {
 mockUserRepository = MockUserRepository();
 usecase = GetNumberOfFollowing(mockUserRepository);
    });
    int   followersNumber = 5 ;
    test(
      'should get Number of following ',
      ()async{
when(mockUserRepository.getNumberOfFollowing("user_123")).thenAnswer((_) async => Right(followersNumber) );

final result = await usecase("user_123");

expect(result,Right(followersNumber));
verify(mockUserRepository.getNumberOfFollowing("user_123"));
verifyNoMoreInteractions(mockUserRepository);
      }
    );
    
 
}



