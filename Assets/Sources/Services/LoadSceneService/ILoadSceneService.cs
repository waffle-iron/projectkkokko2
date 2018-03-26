using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ILoadSceneService
{
    void LoadScene (string name);
    string ActiveScene { get; }
}

