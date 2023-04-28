import 'package:flutter/material.dart';


class PublishButton extends StatelessWidget {
  const PublishButton({super.key});

  @override
  Widget build(BuildContext context) {
    return  Container(
                width: 300,
                height: 100,
                padding:const EdgeInsets.fromLTRB(130,30,130,30),
                child: GestureDetector(
                  onTap: () {},
                  child: Container(
                    width: 10,
                    height: 50,
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(50),
                      color: const Color.fromRGBO(55, 106, 237, 1),
                    ),
                    child:const Center(child: Text('Publish',
                    style: TextStyle(
                      fontFamily: 'Poppins',
                      color: Color.fromRGBO(255, 255, 255, 1),
                      fontSize: 15,
                      fontWeight: FontWeight.w500,

                    ),)),
                  ),
                ),
              );
  }
}