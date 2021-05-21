using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySQL_Test.Models
{
    /// <summary>
    /// User클래스는 users라느 체이블에 들어가는 각각의 요소들을 정의
    /// </summary>
    class User
    {
        //각각의 테이블 열이 됨
        [Key]
        [Required]
        [MaxLength(30)]
        public string userId { get; set; }

        [Required]
        [MaxLength(30)]
        public string userName { get; set; }

        [Required]
        [MaxLength(30)]
        public string userAddress { get; set; }


    }
}
