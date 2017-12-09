﻿module Day_05_pt1

open FsUnit
open NUnit.Framework

let defaultDelimiters = [|",";"\n";System.Environment.NewLine|]

let split (delimiters:string array) (text:string) = 
    text.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries)

let input1 = "0
3
0
1
-3"

let input2 = "1
2
0
0
0
2
-2
-2
-3
-3
-7
0
-1
0
-10
-8
-12
-8
-3
-6
0
0
-18
-17
-11
-18
1
-7
-10
-4
-18
-8
-26
-15
-24
0
-8
-17
-15
-24
-7
-21
-15
-19
-30
-40
-44
-23
-3
-25
2
-31
-20
-45
-51
-50
-34
-4
-33
-41
0
-49
-43
0
-62
1
1
-32
-50
-22
-10
-60
-13
-46
-57
-40
-28
-33
-34
-13
-40
-5
-49
-17
-25
-71
-5
-16
-23
-58
-69
-22
-28
-84
-70
-71
-73
-87
-8
-11
-99
-65
-27
-32
-48
-87
-96
1
-58
-101
-94
2
-52
-34
-22
2
-25
-7
-36
-66
-84
-100
-45
-65
-69
-52
-5
-4
-93
-100
-7
-13
-50
-87
-87
-4
-119
-25
1
-41
-58
-24
-12
-15
-39
-140
-40
-136
-88
-141
-112
-43
-68
-67
-128
-23
-24
-90
-56
-71
-146
-46
-41
-76
-54
-38
-144
-53
-1
-97
0
0
-70
-60
-171
-12
-97
-147
-21
-174
-108
-101
-91
-56
-76
-13
-177
-1
-40
-2
-177
-136
-168
-126
-5
-175
-177
-144
-104
-174
-4
-172
-114
-69
-18
-24
-157
-47
-110
-6
-155
-79
-157
-93
-93
-114
-77
-148
-32
-100
-192
-144
-123
-192
-65
-220
-143
-1
-40
-149
-69
-230
-202
-69
-52
-112
-175
-72
-69
-168
-198
-181
-156
-37
-179
-168
-81
-51
-205
-2
-104
-25
-199
-83
-176
-115
-174
-204
-207
-127
-161
-219
-27
-107
-160
-141
-34
-39
-182
-46
-41
-90
-267
-234
-48
-72
-49
-110
-266
-167
-194
-124
-183
-184
-108
-49
-130
-166
-198
-87
-196
-183
-275
-130
-275
-39
-70
-143
-257
-22
-53
-12
-93
-30
-141
-32
-239
-284
-186
-211
-160
-145
-21
-167
-258
-67
-56
-262
-272
-19
-194
-244
-95
-261
-27
-109
-271
-7
-146
-328
-266
-207
-76
-204
-273
-177
-159
-68
-231
-215
-75
-264
-27
-342
-298
-338
-178
-268
-303
-78
-283
-149
-147
-209
-146
-147
-282
-131
-204
-129
-319
-166
-256
-114
-267
-211
-15
-194
-53
-114
-236
-127
-33
-316
-123
-180
-234
-131
-107
-21
-209
-174
-174
-24
-1
-281
-367
-251
-42
-17
-158
-33
-181
-26
-286
-235
-262
-1
-374
-121
-253
-215
-19
-114
-8
-372
-89
-185
-50
-71
-130
-248
-274
-9
-99
-66
-402
-256
-294
-313
-256
-36
-229
-64
-47
-32
-259
-178
-278
-416
-334
-286
-229
-377
-50
-424
-359
-182
-41
-270
-96
-372
-1
-100
-45
-88
-111
-373
-247
-185
-356
-66
-246
-157
-326
-196
-258
-325
-218
-43
-224
-429
-461
-159
-101
-21
-187
-416
-154
-416
-311
-54
-189
-379
-375
-300
0
-405
-170
-478
-119
-451
-121
-30
-304
-320
-218
-369
-294
-41
-328
-482
-42
-200
-254
-409
-260
-447
-196
-156
-394
-142
-180
-376
-316
-323
-455
-262
-360
-143
-318
-242
-226
-382
-211
-493
-443
-14
-231
-304
-168
-396
-100
-201
-187
-209
-49
-45
-150
-309
-275
-449
-523
-260
-366
-222
-483
-234
-209
-398
-247
-343
-266
-456
-396
-528
-232
-241
-482
-417
-362
-406
-503
-164
-146
-198
-285
-23
-133
-506
-159
-203
-70
-35
-410
-209
-482
-304
-45
-550
-27
-6
-117
-121
-143
-265
-196
-179
-334
-77
-253
-526
-276
-437
-212
-276
-253
-414
-192
-48
-53
-28
-24
-139
-554
-534
-82
-35
-237
-447
-274
-125
-377
-404
-101
-241
-166
-192
-120
-469
-461
-534
-222
-409
-363
-211
-477
-300
-491
-506
-512
-344
-554
-31
-617
-49
-268
-63
-143
-512
-115
-299
-344
-453
-573
-590
-330
-342
-347
-3
-46
-344
-423
-561
-411
-95
-9
-323
-354
-523
-523
-526
-573
-162
-281
-578
-326
-475
-506
-319
-190
-15
-193
-586
-430
-166
-72
-160
-530
-233
-626
-345
-253
-413
-152
-217
-672
-675
-498
-417
-104
-25
-114
-283
-187
-314
-51
-88
-217
-311
-408
-148
-420
-615
-221
-454
-461
-213
-131
-115
-326
-244
-561
-133
-50
-434
-544
-616
-418
-302
-366
-202
-624
-302
-241
-158
-494
-321
-555
-136
-601
-363
-246
-630
-705
-121
-427
-91
-453
-664
-271
-210
-155
-573
-232
-349
-152
-208
-233
-395
-185
-121
-291
-149
-11
-263
-55
-488
-78
-155
-447
-667
-556
-730
-406
-454
-382
-496
-568
-235
-374
-200
-475
-513
-275
-423
-95
-643
-434
-144
-527
-418
-577
-564
-211
-485
-122
-387
-484
-212
-129
-763
-268
-83
-428
-518
-394
-784
-223
-549
-232
-175
-566
-569
-329
-300
-3
-563
-571
-369
-753
-111
-609
-461
-514
-514
-174
-800
-702
-808
-780
-708
-774
-811
-518
-741
-404
-364
-48
-74
-228
-333
-380
-90
-813
-457
-275
-414
-281
-723
-101
-123
-438
-657
-406
-779
-161
-825
-715
-79
-358
-183
-554
-716
-596
-56
-39
-505
-268
-425
-609
-69
-92
-7
-44
-10
-681
-86
-30
-225
-551
-213
-335
-829
-817
-804
-74
-109
-732
-781
-401
-370
-40
-526
-694
-336
-859
-294
-682
-264
-325
-27
-679
-135
-82
-711
-570
-159
-179
-604
-41
-580
-403
-540
-262
-69
-329
-5
-879
-345
-632
-367
-183
-38
-80
-63
-448
-832
-656
-774
-292
-474
-596
-862
-842
-16
-107
-243
-647
-782
-336
-785
-816
-78
-416
-712
-810
-389
-264
-304
-847
-520
-619
-161
1
-584
-719
-486
-516
-360
-747
-363
-672
-134
-177
-894
-778
-582
-766
-769
-114
-843
-287
-493
-30
-620
-467
-141
-206
-437
-367
-426
-799
-943
-508
-594
-545
-61
-829
-844
-589
-775
-409
-28
-726
-452
-261
-613
-106
-441
-496
-643
-606
-742
-408
-321
-260
-333
-328
-751
-21
-768
-36
-265
-936
-697
-702
-924
-89
-215
-896
-216
-477"

type GameState = {
  instructions : array<int>
  programCounter : int
  ended : bool
}

let solver input = 
  let instructions = 
    input
    |> split defaultDelimiters
    |> Seq.map int
    |> Seq.toArray


  let initialState = {
    instructions = instructions;
    programCounter = 0;
    ended = false
  }

  let nextState (state: GameState) =
    let newInstructions = 
      state.instructions 
      |> Array.mapi(fun i v -> 
        if i = state.programCounter 
        then v + 1
        else v
    )
  
    let move = (state.instructions |> Seq.tryItem (state.programCounter) )
    match move with
    | Some(move) -> 
      {
        instructions = newInstructions;
        programCounter = state.programCounter + move
        ended = false
      }
    | None -> {state with ended = true}

  Seq.unfold (fun state -> 
    let a = state |> nextState; 
    Some(a,a)) initialState
  |> Seq.takeWhile (fun state -> state.ended = false)
  |> Seq.length

[<Test>]
let ``simple``()=
  input1 |> solver |> should equal 5

[<Test>]
let realTest()=
  input2 |> solver |> (printfn "Answer %d")

