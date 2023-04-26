import "package:flutter/material.dart";
import '../../../core/utils/colors.dart';

// This widget acceps index and returns pagination dots making the index active
class SlideDotes extends StatefulWidget {
  SlideDotes({required this.index, super.key});
  int index;

  @override
  State<SlideDotes> createState() => _SlideDotesState();
}

class _SlideDotesState extends State<SlideDotes> {
  @override
  Widget build(BuildContext context) {
    return Row(
      children: List.generate(3, (index) {
        return Padding(
          padding: const EdgeInsets.only(right: 10),
          child: Container(
            width: widget.index == index ? MediaQuery.of(context).size.height * 0.03 : MediaQuery.of(context).size.height * 0.014,
            height: MediaQuery.of(context).size.height * 0.014,
            decoration: BoxDecoration(
              color:
                  widget.index == index ? primaryColor : scaffoldBackground,
              borderRadius: BorderRadius.circular(50),
            ),
          ),
        );
      }),
    );
  }
}
